let brandAverageProductRating = [];
getdata();

async function getdata() {
    await fetch('http://localhost:51395/Stat/BrandAverageProductRating')
        .then(x => x.json())
        .then(y => {
            brandAverageProductRating = y;
        }).then(() => display());
}

function display() {
    document.getElementById('resultBrandAverageProductRating').innerHTML = "";
    brandAverageProductRating.forEach(t => {
        document.getElementById('resultBrandAverageProductRating').innerHTML +=
            `<tr>
                <td>${t.brandName}</td>
                <td>${t.averageRating}</td>
            </tr>`
    });
}