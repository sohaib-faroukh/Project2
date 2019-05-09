import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'keyValuefilter',
  //pure: false,
})
export class KeyValuePipe implements PipeTransform {

  transform(array_: any[], key: string, value: string | boolean | number): any {

    if (typeof (value) == 'string') {
      value= value.trim().toLowerCase();
      return array_.filter(ele => ele[key].toLowerCase().includes(value));
    }
    else if(typeof(value)=='number' || typeof(value)=='boolean'){
      return array_.filter(ele => ele[key] == value);
    }
    return array_;
  }

}
