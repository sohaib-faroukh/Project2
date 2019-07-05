import { isArray, isObject } from "util";
import * as jQuery from 'jquery';
import 'bootstrap-notify';


let $: any = jQuery;

export function showNotification(Message: string, From: string, Align: string, Type: string) {

  $[`notify`]({// options
    icon: 'glyphicon glyphicon-warning-sign',
    title: 'Notification',
    message: Message,
    // url: 'https://github.com/mouse0270/bootstrap-notify',
    // target: '_blank'
  }, {
      // settings
      element: 'body',
      position: null,
      type: Type.trim().toLowerCase(),
      allow_dismiss: true,
      newest_on_top: false,
      showProgressbar: false,
      placement: {
        from: From.trim().toLowerCase(),
        align: Align.trim().toLowerCase()
      },
      offset: 20,
      spacing: 10,
      z_index: 1031,
      delay: 5000,
      timer: 1000,
      url_target: '_blank',
      mouse_over: null,
      animate: {
        enter: 'animated fadeInDown',
        exit: 'animated fadeOutUp'
      },
      onShow: null,
      onShown: null,
      onClose: null,
      onClosed: null,
      icon_type: 'class',

      template:

      
        '<div data-notify="container" class="col-xs-11 col-sm-6 alert alert-{0}" role="alert">' +
          '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
          '<span data-notify="icon"></span> ' +
          // '<span data-notify="title">{1}</span> ' +
          '<span data-notify="message">{2}</span>' +
          '<div class="progress" data-notify="progressbar">' +
          	'<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
          '</div>' +
          // '<a href="{3}" target="{4}" data-notify="url"></a>' +
        '</div>'

    });

}


export function catchConnectionError(err: any) {
  console.log(err);
}



export function extract_keys(arr: any): string[] {
  let res: string[] = [];
  if (isArray(arr) && arr.length > 0) {
    for (let key in arr[0]) {
      res.push(key);
    }
    return res.length > 0 ? res : null;
  }
  else if (isObject(arr)) {
    for (let key in arr) {
      res.push(key);
    }
    return res.length > 0 ? res : null;
  }
}





export function onValueChange(comp: any, toCompareWith: any): boolean {
  let thereIschange = false;
  for (let key in comp) {
    if (isArray(comp[key])) {
      if (comp[key].length == toCompareWith[key].length) {
        comp[key].forEach(ele => {
          if (toCompareWith[key].find(it => it.id == ele.id) == null) {
            //deference between tow array of objects content 
            thereIschange = true;

          }
        });
      }
      else {
        // not matching length
        thereIschange = true;
      }
    }
    else {
      if (comp[key] !== toCompareWith[key]) {
        // premitive type string value changes 
        thereIschange = true;

      }
    }
    if (thereIschange == true) {
      break;
    }
  }
  return thereIschange;
}
