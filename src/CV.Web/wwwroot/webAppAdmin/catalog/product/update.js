Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                id: ""
            },
            catalogSectors: "",
            catalogFunctions: "",
            langs: []
        };
    },
    validations: {
        objModel: {
            name: {
                required,
                minLength: minLength(1)
            }
        }
    },
    methods: {
        loadDetail: function () {
            var self = this;
            self.objModel.id = $('#productId').data("productid");
            
            axios.get('/api/product/getProduct/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
                    $('#urlImage').val(self.objModel.urlImage);
                    $('#hexa-colorpicker').val(self.objModel.color);
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadSector: function () {
            var self = this;
            axios.get('/api/catalogFunction/get', null)
                .then(function (response) {
                    self.catalogFunctions = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadFunction: function () {
            var self = this;

            axios.get('/api/catalogSector/get', null)
                .then(function (response) {
                    self.catalogSectors = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        save: function () {
            var self = this;
            self.objModel.urlImage = $('#urlImage').val();
            self.objModel.color = $('#hexa-colorpicker').val();
            axios.put('/api/product/update/' + self.objModel.id, self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/product/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadLang: function () {
            var self = this;
            axios.get('/api/setting/GetLanguages/', null)
                .then(function (response) {
                    self.langs = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        this.loadLang();
        this.loadFunction();
        this.loadSector();
        this.loadDetail();
    }
});