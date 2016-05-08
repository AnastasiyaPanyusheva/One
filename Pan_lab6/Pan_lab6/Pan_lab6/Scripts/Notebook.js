$(document).ready(function () {

    var note = function(name, text) 
    {
        this.Name = name;
        this.Text = text;
    }

    var vm = {
        image: ko.observable(),
        notename: ko.observable(),
        current: -1,
        text: ko.observable(),
        notebook: ko.observableArray([]),
        create: function () {
            if (vm.notename() == "") return true;
            var exist = false;
            ko.utils.arrayForEach(vm.notebook(), function (item) {
                if (item.Name == vm.notename()) {
                    exist = true;
                }
            });
            if (exist == false)
            {
                vm.notebook.push(new note(vm.notename(),""));
            }
            vm.current = vm.notebook().length - 1;
            $('.listnotepad').parent().children().removeClass('active');
            $('.listnotepad').eq(vm.current).addClass('active');
            var data = new note(vm.notename(), "");
            $.ajax({
                type: 'POST',
                url: 'Save',
                data: ko.toJSON(data),
                contentType: 'application/json; charset=utf-8'
            });
            vm.notename('');
            vm.text('');
            Image();
        },
        save: function () {
            if (vm.current != -1)
            {
                vm.notebook()[vm.current].Text = vm.text();
            }
            var data = new note(vm.notebook()[vm.current].Name, vm.text());
            $.ajax({
                type: 'POST',
                url: 'Save',
                data: ko.toJSON(data),
                contentType: 'application/json; charset=utf-8'
            });
        },
        selected: function (data,event) {
            $(event.target).parent().children().removeClass('active');
            $(event.target).addClass('active');
            vm.notename('');
            vm.current = $(".listnotepad").index($(event.target));
            vm.text(vm.notebook()[vm.current].Text);
            Image();
        }
    };

    ko.applyBindings(vm);
    Load();
    function Load()
    {
        $.getJSON("Load", function (data) {
            if(data != [])
            vm.notebook(data);
        }).done(function () {
            var current = false;
            for (var item in vm.notebook()) {
                if (vm.notebook()[item].Name == notebookName) {
                    vm.current = item;
                    current = true;
                }
            }
            if(!current) vm.current = vm.notebook().length - 1;
            $('.listnotepad').parent().children().removeClass('active');
            $('.listnotepad').eq(vm.current).addClass('active');
            vm.text(vm.notebook()[vm.current].Text);
            vm.notename('');
            Image();
        });
    }
    function Image()
    {
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var url = window.URL || window.webkitURL;
                vm.image(url.createObjectURL(this.response));
            }
        }
        var formData = new FormData();
        formData.append('Name', vm.notebook()[vm.current].Name);
        xhr.open('POST', 'Image', true)
        xhr.responseType = 'blob';
        xhr.send(formData);
    }
});