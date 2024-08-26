const num = Number(localStorage.getItem('productId'));
var url = `https://localhost:7143/api/Products/GetProductsBasedOnCategoryId/${num}`;

async function getProductsDetails() {
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("container");
  data.forEach(element => {
  cards.innerHTML += `
         <div class="card" style="width: 18rem;">
            <img src="${element.productImage}" class="card-img-top" alt=;
            <div class="card-body">
                <h5 class="card-title">${element.productName}</h5>
                <h4 ">Price: ${element.price}</h4>
                <p>${element.description}</p>
            </div>
        </div>`;
  });
  console.log(data);


};

getProductsDetails();
