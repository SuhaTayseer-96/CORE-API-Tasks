const num = Number(localStorage.getItem('productId'));
var url = `https://localhost:7143/api/Products/getProductById/${num}`;

async function getProductsDetails() {
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("container");
  console.log(data);
  data.forEach(element => {
  cards.innerHTML = `
         <div class="card" style="width: 18rem;">
            <img src="..." class="card-img-top" alt=${element.productImage};
            <div class="card-body">
                <h5 class="card-title">${element.productName}</h5>
                <h4 ">Price: ${element.price}</h4>
                <p>${element.description}</p>
            </div>
        </div>`;
  });

getProductsDetails();

}

