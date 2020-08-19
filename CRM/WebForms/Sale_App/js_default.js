KindEditor.ready(function(K) {
			var editor1 = K.create('#content1', {
                cssPath: '../../kind/plugins/code/prettify.css',
                uploadJson: '../../kind/upload_json.ashx',
                fileManagerJson: '../../kind/file_manager_json.ashx',
				allowFileManager : true,
				resizeType : 1,
				newlineTag: 'br',
				
				afterCreate : function() {
					var self = this;
					
				}
			});
			prettyPrint();
		});



