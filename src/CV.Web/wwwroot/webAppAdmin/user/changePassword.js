Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                oldPassword: "",
                newPassword: ""
            }
        };
    },
    validations: {
        objModel: {
            oldPassword: {
                required,
                minLength: minLength(3)
            },
            newPassword: {
                required,
                minLength: minLength(2)
            }
        }
    },
    methods: {
        save: function () {
            var self = this;

            axios.post('/api/user/updatePassword', self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/user/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
    }
});