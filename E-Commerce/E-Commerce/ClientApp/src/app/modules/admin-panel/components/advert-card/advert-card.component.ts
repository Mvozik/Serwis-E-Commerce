import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-advert-card',
  templateUrl: './advert-card.component.html',
  styleUrls: ['./advert-card.component.scss'],
})
export class AdvertCardComponent implements OnInit {
  @Input() name: string;
  @Input() photoUrl: string;
  @Input() price: number;

  constructor() {}

  ngOnInit(): void {
    if (!this.photoUrl) {
      this.photoUrl = '../../../../../assets/photos/default.svg';
    }
  }
}
