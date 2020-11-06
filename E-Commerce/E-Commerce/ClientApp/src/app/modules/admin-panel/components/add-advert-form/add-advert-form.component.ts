import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { baseUrl } from '../../../../../environments/environment';

@Component({
  selector: 'app-add-advert-form',
  templateUrl: './add-advert-form.component.html',
  styleUrls: ['./add-advert-form.component.scss']
})
export class AddAdvertFormComponent implements OnInit {

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }

  
}
