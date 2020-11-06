import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styleUrls: ['./mainpage.component.scss']
})
export class MainpageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void 
  {

  }

  slides = [{'image': "./../../../../../assets/photos/baner1.jpg"},{'image': "./../../../../../assets/photos/baner2.jpg"},{'image': "./../../../../../assets/photos/baner3.jpg"},];

}
