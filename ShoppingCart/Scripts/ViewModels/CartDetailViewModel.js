function CartDetailViewModel(model) {
    var self = this;

    self.sending = ko.observable(false);

    self.cart = model;

    for (var i = 0; i < self.cart.cartItems.length; i++) {
        self.cart.cartItems[i].quantity = ko.observable(self.cart.cartItems[i].quantity).extend({ subTotal: self.cart.cartItems[i].book.salePrice });
    }

    self.cart.cartItems = ko.observableArray(self.cart.cartItems);

    self.cart.total = self.cart.cartItems.total();

    self.cartItemBeingChanged = null;

    self.deleteCartItem = function (cartItem) {
        self.sending(true);

        self.cartItemBeingChanged = cartItem;

        $.ajax({
            url: '/api/cartitems',
            type: 'delete',
            contentType: 'application/json',
            data: ko.toJSON(cartItem)
        })
            .success(self.successfulDelete)
            .error(self.errorSave)
            .complete(function () { self.sending(false) });
    };

    self.successfulDelete = function (data) {
        $('.body-content').prepend('<div class="alert alert-success"><strong>Powodzenie!</strong> Pozycja została usunięta z koszyka.</div>');

        self.cart.cartItems.remove(self.cartItemBeingChanged);

        cartSummaryViewModel.deleteCartItem(ko.toJS(self.cartItemBeingChanged));

        self.cartItemBeingChanged = null;
    };

    self.errorSave = function () {
        $('.body-content').prepend('<div class="alert alert-danger"><strong>Błąd!</strong> Wystąpił błąd podczas aktualizowania pozycji koszyka.</div>');
    };

    self.fadeOut = function (element) {
        $(element).fadeOut(1000, function () {
            $(element).remove();
        });
    };
};