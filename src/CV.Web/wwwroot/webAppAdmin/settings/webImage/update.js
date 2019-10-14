Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                id: ""
            },
            positions: []
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
        save: function () {
            var self = this;
            self.objModel.urlImage = $('#urlImage').val();
            axios.put('/api/webImage/update/' + self.objModel.id, self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/webImage/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadDetail: function () {
            var self = this;
            self.objModel.id = $('#imageId').data("imageid");
            axios.get('/api/webImage/getImage/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadPosition: function () {
            var self = this;
            axios.get('/api/webImage/GetPosition/', null)
                .then(function (response) {
                    self.positions = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        this.loadPosition();
        this.loadDetail();
    }
});