let shopNumberOfProduct = [];
getdata();

async function getdata() {
    await fetch('http://localhost:51395/Stat/ShopNumberOfProduct')
        .then(x => x.json())
        .then(y => {
            shopNumberOfProduct = y;
        }).then(() => display());
}

function display() {
    document.getElementById('resultShopNumberOfProduct').innerHTML = "";
    shopNumberOfProduct.forEach(t => {
        document.getElementById('resultShopNumberOfProduct').innerHTML +=
            `<tr>
                <td>${t.shopName}</td>
                <td>${t.numberOfProduct}</td>
            </tr>`
    });
}