Vue.component('paginate', VuejsPaginate);

var app = new Vue({
    el: '#appjs',
    data() {
        return {
            list: [],
            pCount: 0,
            pSize: 20,
            page: 1
        };
    },
    methods: {
        loadData: function (page) {
            var self = this;

            var params = {
                page: self.page,
                pageSize: self.pSize
            };

            axios.get('/api/user/get', { params})
                .then(function (response) {
                    self.list = response.data.results;
                    self.pCount = response.data.pageCount;
                })
                .catch(function (error) {
                    alert("ERROR: " + (error.message | error));
                });
        }
    },
    created: function () {
        this.loadData(this.page);
    }
});