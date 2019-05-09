import { isArray, isObject } from "util";


export function catchConnectionError(err:any){
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
