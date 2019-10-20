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
            axios.put('/api/pageContent/update/' + self.objModel.id, self.objModel)
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
        },
        loadDetail: function () {
            var self = this;
            self.objModel.id = $('#pageId').data("pageid");
            axios.get('/api/pageContent/getPage/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
                    self.pushlishDate = moment(self.objModel.pushlishDate).format('DD-MM-YYYY hh:mm');
                    $('#content').summernote('code', self.objModel.content);
                    $('#urlImage').val(self.objModel.urlImage);
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