Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                name: "",
                address: "",
                phone: "",
                hotLine: "",
                email: "",
                fax: "",
                zalo: "",
                password: "",
                portEmail: "",
                smtpEmail: "",
                urlMap: ""
            },
            infoTypes: []
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
            axios.post('/api/info/create', self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/info/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadInfoType: function () {
            var self = this;
            axios.get('/api/info/getAllType/', null)
                .then(function (response) {
                    self.infoTypes = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        this.loadInfoType();
    }
});