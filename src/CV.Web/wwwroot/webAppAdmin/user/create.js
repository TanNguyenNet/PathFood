Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                userName: "",
                firstName: "",
                lastName: "",
                email: "",
                password: "",
                claims: []
            },
            claims: []
        };
    },
    validations: {
        objModel: {
            userName: {
                required,
                minLength: minLength(3)
            },
            firstName: {
                required,
                minLength: minLength(2)
            },
            lastName: {
                required,
                minLength: minLength(3)
            },
            email: {
                email
            },
            password: {
                required,
                minLength: minLength(6)
            }
        }
    },
    methods: {
        save: function () {
            var self = this;

            axios.post('/api/user/create', self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/user/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadClaim: function () {
            var self = this;
            axios.get('/api/policy/Get/', null)
                .then(function (response) {
                    self.claims = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        this.loadClaim();
    }
});