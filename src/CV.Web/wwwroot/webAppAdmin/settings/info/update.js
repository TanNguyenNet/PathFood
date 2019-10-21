Vue.use(window.vuelidate.default);
const { required, minLength, sameAs, email } = window.validators;

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            objModel: {
                id: ""
               
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
            axios.put('/api/info/update/' + self.objModel.id, self.objModel)
                .then(function (response) {
                    window.location.href = "/admin/info/index";
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        loadDetail: function () {
            var self = this;
            self.objModel.id = $('#infoId').data("infoid");
            axios.get('/api/info/getInfo/' + self.objModel.id, null)
                .then(function (response) {
                    self.objModel = response.data;
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
        this.loadDetail();
    }
});