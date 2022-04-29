let shopAveragePrice = [];
getdata();

async function getdata() {
    await fetch('http://localhost:51395/Stat/ShopAveragePrice')
        .then(x => x.json())
        .then(y => {
            shopAveragePrice = y;
        }).then(() => display());
}

function display() {
    document.getElementById('resultShopAveragePrice').innerHTML = "";
    shopAveragePrice.forEach(t => {
        document.getElementById('resultShopAveragePrice').innerHTML +=
            `<tr>
                <td>${t.shopName}</td>
                <td>${t.averagePrice}$</td>
            </tr>`
    });
}