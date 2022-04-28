let brands = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53910/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BrandCreated", (user, message) => {
        getdata();
    });

    connection.on("BrandDeleted", (user, message) => {
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
    brands = [];
    await fetch('http://localhost:51395/Brand')
        .then(x => x.json())
        .then(y => {
            brands = y;
            console.log(brands);
            display();
        });
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
            </tr>`
    });
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
    let brandId = brands.pop().brandId + 1;
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