ko.bindingHandlers["dotvvm-contrib-BootstrapMaskedInput-Text"] = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var mask = ko.unwrap(allBindingsAccessor()["dotvvm-contrib-BootstrapMaskedInput-Mask"]);
        var placeholder = allBindingsAccessor().placeholder;
        if (placeholder) {
            $(element).mask(mask, { placeholder: placeholder });
        } else {
            $(element).mask(mask);
        }
        ko.utils.registerEventHandler(element, "change", function () {
            console.log("Change event");
            var observable = valueAccessor();
            observable($(element).val());
        });
    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        console.log("element value: " + value);
        $(element).val(value);
    }
};
