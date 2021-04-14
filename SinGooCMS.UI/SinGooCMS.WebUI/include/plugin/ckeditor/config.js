/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    config.language = 'zh-cn';
    //config.uiColor = '#AADC6E';

    // ����������
    // config.toolbar = "Basic";    
    // ȫ�ܹ�����
    //config.toolbar = "Full";    
    // �Զ��幤����
    config.toolbar_Full =
    [
        ['Source', '-', 'Preview'], ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'],
        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote', 'CodeSnippet', 'ShowBlocks'], '/',
        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'], ['Link', 'Unlink', 'Anchor'],
        ['addpic', 'Flash', 'Table', 'HorizontalRule', 'SpecialChar', 'Smiley'], '/',
        ['Styles', 'Format', 'Font', 'FontSize', "lineheight"], ['TextColor', 'BGColor'], ['Maximize', '-', 'About']
    ];
    config.toolbar_Basic =
    [
        ['Source', '-', 'Preview'], ['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', 'FontSize', 'addpic', 'TextColor', 'BGColor'], ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'Maximize']
    ];

    config.extraPlugins = 'addpic,clipboard,lineutils,widget,dialog,codesnippet';

    //config.extraPlugins = 'addpic';
    config.filebrowserWindowWidth = '800';  //��������������������size����
    config.filebrowserWindowHeight = '500';    
};
