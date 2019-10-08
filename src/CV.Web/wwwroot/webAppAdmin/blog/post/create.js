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
                active: true,
                pushlishDate: moment(new Date()),
                lang: 1,
                content: "",
                categoryBlogId: "",
                setHomePage: false
            },
            pushlishDate: moment(new Date()).format('DD-MM-YYYY hh:mm'),
            langs: [],
            cats: []
        };
    },
    mounted: function () {
        var self = this;

        $('#pushlishDate').flatpickr({
            enableTime: true,
            dateFormat: "d-m-Y H:i"
        });
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
            self.objModel.pushlishDate = moment(self.pushlishDate, "DD-MM-YYYY HH:ss").format();
            self.objModel.content = $('#content').val();
            axios.post('/api/post/create', self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/post/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadCategory: function () {
            var self = this;
            axios.get('/api/categoryBlog/get/', null)
                .then(function (response) {
                    self.cats = response.data;
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
        this.loadCategory();
    }
});