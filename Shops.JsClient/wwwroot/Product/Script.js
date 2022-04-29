let Products = [];
let connection = null;
let ProductIdToUpdate;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:51395/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ProductCreated", (user, message) => {
        getdata();
    });

    connection.on("ProductDeleted", (user, message) => {
        getdata();
    });

    connection.on("ProductUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:51395/Product')
        .then(x => x.json())
        .then(y => {
            Products = y;
            Products.sort((a, b) => a.productdId - b.productdId);
        }).then( () => display());
}

function display() {
    document.getElementById('resultProduct').innerHTML = "";
    Products.forEach(t => {
        document.getElementById('resultProduct').innerHTML +=
            `<tr>
                <td>${t.productdId}</td>
                <td>${t.productName}</td>
                <td>${t.productPrice}</td>
                <td>${t.productColour}</td>
                <td>${t.stockNumber}</td>
                <td>${t.usresRating}</td>
                <td><button type="button" onclick="remove(${t.productdId})">Delete</button></td>
                <td><button type="button" onclick="showupdate(${t.productdId})">Update</button></td>
            </tr>`
    });
}

function showupdate(id) {
    let Product = Products.find(t => t['productdId'] == id);
    document.getElementById('ProductNameToUpdate').value = Product.productName;
    document.getElementById('ProductPriceToUpdate').value = Product.productPrice;
    document.getElementById('ProductColourToUpdate').value = Product.productColour;
    document.getElementById('StockNumberToUpdate').value = Product.stockNumber;
    document.getElementById('UsresRatingToUpdate').value = Product.usresRating;
    document.getElementById('updateform').style.display = 'flex';
    document.getElementById('form').style.display = 'none';
    ProductIdToUpdate = id;
}

function update() {
    let productName = document.getElementById('ProductNameToUpdate').value;
    let productPrice = document.getElementById('ProductPriceToUpdate').value;
    let productColour = document.getElementById('ProductColourToUpdate').value;
    let stockNumber = document.getElementById('StockNumberToUpdate').value;
    let usresRating = document.getElementById('UsresRatingToUpdate').value;

    fetch('http://localhost:51395/Product', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                productdId: ProductIdToUpdate,
                brandrId: 0,
                productName: productName,
                productPrice: productPrice,
                productColour: productColour,
                stockNumber: stockNumber,
                usresRating: usresRating,
            }
        )
    }).then(data => {
        if (data.status == 200) {
            document.getElementById('updateform').style.display = 'none';
            document.getElementById('form').style.display = 'flex';
            getdata();
        }
    }).catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:51395/Product/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let ProductId;
    if (Products.length == 0) {
        ProductId = 0;
    } else {
        ProductId = Products.pop().ProductId + 1;
    }
    let productName = document.getElementById('ProductName').value;
    let productPrice = document.getElementById('productPrice').value;
    let productColour = document.getElementById('productColour').value;
    let stockNumber = document.getElementById('stockNumber').value;
    let usresRating = document.getElementById('usresRating').value;

    fetch('http://localhost:51395/Product', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                ProductId: ProductId,
                brandrId: 0,
                productName: productName,
                productPrice: productPrice,
                productColour: productColour,
                stockNumber: stockNumber,
                usresRating: usresRating,
            }
        )
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}