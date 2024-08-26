async function getAllCategory() {
    let url = "https://localhost:7143/api/Orders/categories";
    let response = await fetch(url);    
let data = await response.json();

let cards = document.getElementById("container")
data.forEach(category => {
   cards.innerHTML += 
   `
   <div class="card" style="width: 18rem;">
   <img class="card-img-top" src="..." alt="${category.categoryImage}">
   <div class="card-body">
     <h5 class="card-title">${category.categoryName}</h5>
     <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
   </div>
   <div class="card-body">
<a href="/category/product/Product.html" onClick="store(${category.categoryId})" class="btn btn-primary">Show Products</a>
   </div>
 </div>`;

});
    console.log(data);
}
function store(id) {
  localStorage.categoryId = id;

}
function clearProduct(){
  localStorage.removeItem("categoryId");
}
getAllCategory();
