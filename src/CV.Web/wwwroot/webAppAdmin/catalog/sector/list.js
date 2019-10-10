Vue.component('paginate', VuejsPaginate);
window.Vue.use(VuejsDialog.main.default);

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            list: []
        };
    },
    methods: {
        loadData: function (page) {
            var self = this;

            var filter = {
                page: self.page,
                pageSize: self.pSize
            };

            axios.get('/api/catalogSector/get', filter)
                .then(function (response) {
                    self.list = response.data;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        },
        deleteItem: function (id) {
            var self = this;

            self.$dialog
                .confirm('Bạn muốn xóa')
                .then(function (dialog) {
                    axios.delete('/api/catalogSector/delete/' + id, null)
                        .then(function (response) {
                            self.loadData(self.page);
                        })
                        .catch(function (error) {
                            alert("ERROR: " + (error.message | error));
                        });
                })
                .catch(function () {
                    console.log('Error');
                });


        }
    },
    created: function () {
        this.loadData(this.page);
    }
});