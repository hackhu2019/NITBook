var sort = [
            ["小说", "随笔", "散文"],
            ["漫画", "推理", "绘本"]
];

function selectChange(bookSort) {
    var index = bookSort.value;
    if (index != 0) {
        var sort2 = document.getElementById("bookSort2");
        sort2.length = 1;
        for (var i = 0; i < 3; i++) {
            sort2.options.add(new Option(sort[index - 1][i], i + 1))
            console.log(sort[index - 1][i])
        }
    }
}