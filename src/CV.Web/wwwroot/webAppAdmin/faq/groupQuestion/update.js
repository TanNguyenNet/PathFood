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
                minLength: minLength(3)
            }
        }
    },
    methods: {
        loadDetail: function () {
            var self = this;
            self.objModel.id = $('#groupQuestionId').data("gid");
            axios.get('/api/groupQuestion/GetGroupQuestion/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        save: function () {
            var self = this;
            axios.put('/api/groupQuestion/update/' + self.objModel.id, self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/groupQuestion/index";
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