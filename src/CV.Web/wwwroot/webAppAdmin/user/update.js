Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                id: ""
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
            }
        }
    },
    methods: {
        loadClaim: function () {
            var self = this;
            axios.get('/api/policy/Get/', null)
                .then(function (response) {
                    self.claims = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },

        loadDetail: function () {
            var self = this;
            self.objModel.id = $('#userId').data("userid");
            axios.get('/api/user/GetUser/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },

        save: function () {
            var self = this;
            axios.put('/api/user/update/' + self.objModel.id, self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/user/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }

    },
    created: function () {
        this.loadClaim();
        this.loadDetail();
    }
});