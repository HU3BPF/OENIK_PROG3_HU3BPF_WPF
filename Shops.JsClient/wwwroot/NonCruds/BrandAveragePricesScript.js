let brandAverageProductPrice = [];
getdata();

async function getdata() {
    await fetch('http://localhost:51395/Stat/BrandAveragerProductPrice')
        .then(x => x.json())
        .then(y => {
            brandAverageProductPrice = y;
        }).then(() => display());
}

function display() {
    document.getElementById('resultBrandAverageProductPrice').innerHTML = "";
    brandAverageProductPrice.forEach(t => {
        document.getElementById('resultBrandAverageProductPrice').innerHTML +=
            `<tr>
                <td>${t.brandName}</td>
                <td>${t.averagePrice}$</td>
            </tr>`
    });
}