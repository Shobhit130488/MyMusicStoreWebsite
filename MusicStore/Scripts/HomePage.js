

function addToCart(dataset) {
  
    
    $.ajax({
       
        url: '/Cart/Index',
        type:'POST',
        data: dataset
    }).done(function (response) {
        alert(response);
    });
    
   
}