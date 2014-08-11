// 用于连接到创建新记录的JS，这个JS一般在List的页面中使用
function Add() {
    document.location.href = "Add";
}

function AddBySubmit() {
    if (typeof (document.forms[0]) == "undefined") {
        document.location.href = "Add";
    } else {
        document.forms[0].action = "Add";
        document.forms[0].submit();
    }
}

// 带有条件的查询，这个JS一般在List页面中使用
function Query() {
    document.forms[0].action = "Query";
    document.forms[0].submit();
}

// 编辑一条记录，这个JS一般在List页面中使用
function Edit(key) {
    document.location.href = "Edit?key=" + key;
}

// 保存，这个JS一般在添加新记录或者编辑新记录页面中使用
function Save() {
    document.forms[0].submit();
}

// 显示数据列表，比如返回等操作
function List() {
    document.location.href = "List";
}

// 删除数据，在List页面中使用
function Delete(key) {
    if (confirm("确认要删除这条数据吗？")) {
        document.location.href = "Delete?key=" + key;
    }
}

function DeleteAndPagedList(key, currentPageNum, pageSize) {
    if (confirm("确认要删除这条数据吗？")) {
        document.location.href = "Delete?key=" + key + "&currentPageNum=" + currentPageNum + "&pageSize=" + pageSize;
    }
}
