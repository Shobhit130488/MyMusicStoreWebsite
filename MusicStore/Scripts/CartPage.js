function removeFromCart(id) {
   
    $.ajax({
        url: '/Cart/RemoveItem',
        type: 'POST',
        data: {'id':id}
    }).done(function (response) {
        location.reload();
        alert(response);
        });

}
function proceedToPay(amount) {

   

}