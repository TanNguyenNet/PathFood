Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                id: ""
            },
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
            self.objModel.id = $('#catalogId').data("catalogid");
            axios.get('/api/catalogSector/getCatalogSector/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
                    $('#urlImage').val(self.objModel.urlImage);
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        save: function () {
            var self = this;
            self.objModel.urlImage = $('#urlImage').val();
            axios.put('/api/catalogSector/update/' + self.objModel.id, self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/catalogSector/index";
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
        this.loadDetail();
    }
});