import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { InsertCustomerService } from './insert-customer.service';
import { API_BASE_URL } from 'src/app/config/config.service';
import { showNotification } from 'src/app/additional/functions';
import { Router } from '@angular/router';

@Component({
  selector: 'app-insert-customer',
  templateUrl: './insert-customer.component.html',
  styleUrls: ['./insert-customer.component.scss']
})
export class InsertCustomerComponent implements OnInit {

  public NationalNumber: number;
  public NationalNumber1: number;

  data: any;
  imagePreview: string;
  selectedFile: File;
  apiUrl: string = null;
  formData = new FormData();
  selectedAlgo: number = 1;

  selectedFileName: string;


  Code: number = 0;  /* = 0 : existing customer with existing fingerprint and matching => survey response
                        = 1 : existing customer but no fingerprint in database => store the inserterd fingerprint in this customer profile files
                        = 2 : existing customer existing fingerprint in customer files but no matching => Error page the customer verfication failed  
                        = 3 : customer National number dosn't exist => insert new customer info and store the fingerprint in new customer file => survey response 
                        = 4 : the fingerprint image is bad quality and bad to proccecc
                        */

  accuracy: string | number;
  Message: string = "";


  imgUrl: string;

  constructor(
    private router: Router,
    private srv: InsertCustomerService,
    private http: HttpClient,
    @Inject(API_BASE_URL) _apiUrl_: string) {
    this.apiUrl = _apiUrl_;
  }

  ngOnInit() {
  }

  onFileChange(event) {
    console.log(this.formData);
    this.selectedFile = event.target.files[0];
    const reader = new FileReader();
    reader.onload = (_event_) => {
      this.imagePreview = reader.result.toString();
      this.formData.append("FingerPrintFile", this.selectedFile);
      this.imgUrl = reader.result.toString();

    };
    reader.readAsDataURL(this.selectedFile);
  }

  onUploadFile() {


    this.formData.append("NationalNumber", this.NationalNumber.toString())
    this.srv.uploadFileAndNatioNumber(this.selectedAlgo, this.formData).subscribe(
      res => {
        console.log(res);
        showNotification("Uploaded Successfully", "bottom", "center", "success");

        this.Code = res["Code"];

        // For Test always navigate to survey response component
        this.navigateAccordingToCode(this.Code);

      },
      err => {
        showNotification("Error - Uploading Fingerprint error : " + err.statusText, "bottom", "center", "danger");
        this.navigateAccordingToCode(-1);
      })


  }




  /*
      = 0 : existing customer with existing fingerprint and matching => survey response
      = 1 : existing customer but no fingerprint in database => store the inserterd fingerprint in this customer profile files
      = 2 : existing customer existing fingerprint in customer files but no matching => Error page the customer verfication failed  
      = 3 : customer National number dosn't exist => insert new customer info and store the fingerprint in new customer file => survey response 
      = 4 : the fingerprint image is bad quality and bad to proccecc
*/

  navigateAccordingToCode(Code: string | number) {
   
    // Code=4;

    switch (Code) {
      case 0: {
        this.router.navigate([`/survey/surveyResponse/${+this.NationalNumber}`]);
        break
      }
      case 1: {
        this.router.navigate([`/survey/surveyResponse/${+this.NationalNumber}`]);

        break
      }
      case 2: {

        showNotification("Not Match",
          "bottom", "center", "danger");
        this.router.navigate([`**`]);

        break
      }
      case 3: {
        showNotification("the customer National Number isn't existing in company database",
        "bottom", "center", "warning");

        this.router.navigate([`/customers/add`]);

        break
      }
      case 4: {

        showNotification("the inserted fingerprint is <strong> bad quality </strong> please try again",
        "bottom", "center", "danger");
        
        this.router.navigate([`/insertCustomer`]);

        break
      }
      default: {
        this.router.navigate([`**`]);
      }
    }
  }



}
