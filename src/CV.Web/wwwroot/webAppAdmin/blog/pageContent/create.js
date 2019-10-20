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
                lang: 1,
                content: "",
                home: false
            },
            langs: []
        };
    },
    mounted: function () {
        
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
            self.objModel.content = $('#content').val();
            axios.post('/api/pageContent/create', self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/pageContent/index";
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
    }
});