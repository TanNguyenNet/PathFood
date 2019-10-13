Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                name: "",
                urlImage: "",
                description: "",
                color: "#4a81d4",
                catalogSectorId: null,
                catalogFunctionId: null,
                active: true,
                lang: 1
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
                minLength: minLength(3)
            }
        }
    },
    methods: {
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
            axios.post('/api/product/create', self.objModel)
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
    }
});