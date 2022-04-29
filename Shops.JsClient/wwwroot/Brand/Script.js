let brands = [];
let connection = null;
let brandIdToUpdate;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:51395/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getdata();
    });

    connection.on("BrandDeleted", (user, message) => {
        getdata();
    });

    connection.on("BrandUpdated", (user, message) => {
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
    await fetch('http://localhost:51395/Brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            brands.sort((a, b) => a.brandId - b.brandId);
        }).then( () => display());
}

function display() {
    document.getElementById('resultBrand').innerHTML = "";
    brands.forEach(t => {
        document.getElementById('resultBrand').innerHTML +=
            `<tr>
                <td>${t.brandId}</td>
                <td>${t.brandName}</td>
                <td>${t.brandAnnualProfit}</td>
                <td>${t.brandNumberOfProducts}</td>
                <td>${t.brandQuality}</td>
                <td>${t.numberOfUsers}</td>
                <td><button type="button" onclick="remove(${t.brandId})">Delete</button></td>
                <td><button type="button" onclick="showupdate(${t.brandId})">Update</button></td>
            </tr>`
    });
}

function showupdate(id) {
    let brand = brands.find(t => t['brandId'] == id);
    document.getElementById('brandNameToUpdate').value = brand.brandName;
    document.getElementById('brandAnnualProfitToUpdate').value = brand.brandAnnualProfit;
    document.getElementById('brandNumberOfProductsToUpdate').value = brand.brandNumberOfProducts;
    document.getElementById('brandQualityToUpdate').value = brand.brandQuality;
    document.getElementById('numberOfUsersToUpdate').value = brand.numberOfUsers;
    document.getElementById('updateform').style.display = 'flex';
    document.getElementById('form').style.display = 'none';
    brandIdToUpdate = id;
}

function update() {
    let brandName = document.getElementById('brandNameToUpdate').value;
    let brandAnnualProfit = document.getElementById('brandAnnualProfitToUpdate').value;
    let brandNumberOfProducts = document.getElementById('brandNumberOfProductsToUpdate').value;
    let brandQuality = document.getElementById('brandQualityToUpdate').value;
    let numberOfUsers = document.getElementById('numberOfUsersToUpdate').value;

    fetch('http://localhost:51395/Brand', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                brandId: brandIdToUpdate,
                shopID: 0,
                brandName: brandName,
                brandQuality: brandQuality,
                brandAnnualProfit: brandAnnualProfit,
                brandNumberOfProducts: brandNumberOfProducts,
                numberOfUsers: numberOfUsers,
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
    fetch('http://localhost:51395/Brand/' + id, {
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
    let brandId;
    if (brands.length == 0) {
        brandId = 0;
    } else {
        brandId = brands.pop().brandId + 1;
    }
    let brandName = document.getElementById('brandName').value;
    let brandAnnualProfit = document.getElementById('brandAnnualProfit').value;
    let brandNumberOfProducts = document.getElementById('brandNumberOfProducts').value;
    let brandQuality = document.getElementById('brandQuality').value;
    let numberOfUsers = document.getElementById('numberOfUsers').value;

    fetch('http://localhost:51395/Brand', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                brandId: brandId,
                shopID: 0,
                brandName: brandName,
                brandQuality: brandQuality,
                brandAnnualProfit: brandAnnualProfit,
                brandNumberOfProducts: brandNumberOfProducts,
                numberOfUsers: numberOfUsers,
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