Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                urlImage: "",
                url: "",
                Position: 1,
                lang: 1
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
            axios.post('/api/webImage/create', self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/webImage/index";
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
    }
});