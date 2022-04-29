let Shops = [];
let connection = null;
let ShopIdToUpdate;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:51395/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ShopCreated", (user, message) => {
        getdata();
    });

    connection.on("ShopDeleted", (user, message) => {
        getdata();
    });

    connection.on("ShopUpdated", (user, message) => {
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
    await fetch('http://localhost:51395/Shop')
        .then(x => x.json())
        .then(y => {
            Shops = y;
            Shops.sort((a, b) => a.ShopId - b.ShopId);
        }).then( () => display());
}

function display() {
    document.getElementById('resultShop').innerHTML = "";
    Shops.forEach(t => {
        document.getElementById('resultShop').innerHTML +=
            `<tr>
                <td>${t.shopId}</td>
                <td>${t.shopName}</td>
                <td>${t.shopLocation}</td>
                <td>${t.shopLeader}</td>
                <td>${t.shopReliability}</td>
                <td>${t.shopNumberOfWorker}</td>
                <td>${t.shopAnnualProfit}</td>
                <td><button type="button" onclick="remove(${t.shopId})">Delete</button></td>
                <td><button type="button" onclick="showupdate(${t.shopId})">Update</button></td>
            </tr>`
    });
}

function showupdate(id) {
    let Shop = Shops.find(t => t['shopId'] == id);
    document.getElementById('ShopNameToUpdate').value = Shop.shopName;
    document.getElementById('ShopLocationToUpdate').value = Shop.shopLocation;
    document.getElementById('ShopLeaderToUpdate').value = Shop.shopLeader;
    document.getElementById('ShopReliabilityToUpdate').value = Shop.shopReliability;
    document.getElementById('ShopNumberOfWorkerToUpdate').value = Shop.shopNumberOfWorker;
    document.getElementById('ShopAnnualProfitToUpdate').value = Shop.shopAnnualProfit;
    document.getElementById('updateform').style.display = 'flex';
    document.getElementById('form').style.display = 'none';
    ShopIdToUpdate = id;
}

function update() {
    let shopName = document.getElementById('ShopNameToUpdate').value;
    let shopLocation = document.getElementById('ShopLocationToUpdate').value;
    let shopLeader = document.getElementById('ShopLeaderToUpdate').value;
    let shopReliability = document.getElementById('ShopReliabilityToUpdate').value;
    let shopNumberOfWorker = document.getElementById('ShopNumberOfWorkerToUpdate').value;
    let shopAnnualProfit = document.getElementById('ShopAnnualProfitToUpdate').value;

    fetch('http://localhost:51395/Shop', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                shopId: ShopIdToUpdate,
                shopName: shopName,
                shopLocation: shopLocation,
                shopLeader: shopLeader,
                shopReliability: shopReliability,
                shopNumberOfWorker: shopNumberOfWorker,
                shopAnnualProfit: shopAnnualProfit,
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
    fetch('http://localhost:51395/Shop/' + id, {
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
    let ShopId;
    if (Shops.length == 0) {
        ShopId = 0;
    } else {
        ShopId = Shops.pop().shopId + 1;
    }
    let shopName = document.getElementById('ShopName').value;
    let shopLocation = document.getElementById('ShopLocation').value;
    let shopLeader = document.getElementById('ShopLeader').value;
    let shopReliability = document.getElementById('ShopReliability').value;
    let shopNumberOfWorker = document.getElementById('ShopNumberOfWorker').value;
    let shopAnnualProfit = document.getElementById('ShopAnnualProfit').value;

    fetch('http://localhost:51395/Shop', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                shopId: ShopId,
                shopName: shopName,
                shopLocation: shopLocation,
                shopLeader: shopLeader,
                shopReliability: shopReliability,
                shopNumberOfWorker: shopNumberOfWorker,
                shopAnnualProfit: shopAnnualProfit,
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