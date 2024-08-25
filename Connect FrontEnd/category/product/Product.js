const number = Number(localStorage.getItem('categoryID'));

if (num == 0) {
    var url = "https://localhost:7143/api/Products";
}
else{
   var url = `https://localhost:7143/api/Products/GetProductsBasedOnCategoryId/${num}`;
}
async function getAllProducts() {
  let response = await fetch(url);    
let data = await response.json();

let cards = document.getElementById("container")
data.forEach(product => {
 cards.innerHTML += 
 `
 <div class="card" style="width: 18rem;">
  <img class="card-img-top" src="${product.productImage}" alt="${product.productImage}">
  <div class="card-body">
    <h5 class="card-title">${product.productName}</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
  <div class="card-body">
    <a href="prodDets.html" class="btn btn-primary" onclick="productId(${product.productId})>more details</a>
  </div>
</div>`;

});

}
getAllProducts();

function productId(data){

  localStorage.setItem("productId", data);
}