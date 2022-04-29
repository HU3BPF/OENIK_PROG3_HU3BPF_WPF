let shopAverageRating = [];
getdata();

async function getdata() {
    await fetch('http://localhost:51395/Stat/ShopAverageRating')
        .then(x => x.json())
        .then(y => {
            shopAverageRating = y;
        }).then(() => display());
}

function display() {
    document.getElementById('resultShopAverageRating').innerHTML = "";
    shopAverageRating.forEach(t => {
        document.getElementById('resultShopAverageRating').innerHTML +=
            `<tr>
                <td>${t.shopName}</td>
                <td>${t.averageRating}</td>
            </tr>`
    });
}