function addToCart(prodId) {
    var count = document.getElementById('countCart').innerHTML;
    //var count1 = document.getElementById('countCart1').innerHTML;
    //var count2 = document.getElementById('countCart2').innerHTML;
    console.log("get value count: " + count);
    var countValue = parseInt(count);
    console.log("count cart: " + countValue);
    console.log("prodId: " + prodId);
    var quantity = 1;
    var Update = 0;
    $.ajax({
        type: "POST",
        url: "/Products/AddToCart",
        data: { ProductId: prodId, Quantity: quantity, Update: Update },
        success: function (result) {
            console.log(result);
            count++;/*count1++;count2++;*/
            console.log("count cart: " + count);
            document.getElementById("countCart").innerHTML = count;           
            //document.getElementById("countCart1").innerHTML = count1;   
            //document.getElementById("countCart2").innerHTML = count2;   
            
           
            return count;
        }
    });
    
};
function notifyMessage(message) {     
    $.notify(message, { position: 'top right', className: 'success', gap: 10 });
    
};




