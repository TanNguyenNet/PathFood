Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                id: ""
            },
            langs: [],
            groupQuestions: []
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
            axios.put('/api/question/update/' + self.objModel.id, self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/question/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadDetail: function() {
            var self = this;
            self.objModel.id = $('#questionId').data("questionid");
            axios.get('/api/question/GetQuestion/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
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
        },
        loadGroupQuestion: function () {
            var self = this;
            axios.get('/api/groupQuestion/get', null)
                .then(function (response) {
                    self.groupQuestions = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        this.loadLang();
        this.loadGroupQuestion();
        this.loadDetail();
    }
});