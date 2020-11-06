import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  constructor() { }
  link:string = "https://www.google.com/search?sxsrf=ALeKk00CQj61CsQ2bfm6d5hMOCwQAfZqcg:1603721639485&ei=pNmWX7e1EeSOrwS8o6HQAg&q=emi%C5%9B&oq=emi%C5%9B&gs_lcp=CgZwc3ktYWIQAzIECCMQJzIECAAQQzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAOgYIIxAnEBM6BQgAELEDOggIABCxAxCDAToICC4QsQMQgwE6BwgAELEDEEM6AgguOgUILhCxA1DKDVi6EWCyEmgAcAB4AIABcIgBjwOSAQMzLjGYAQCgAQGqAQdnd3Mtd2l6wAEB&sclient=psy-ab&ved=2ahUKEwiUkY_VuNLsAhXwtYsKHZ2eBXwQvS4wB3oECAoQGg&uact=5&npsic=0&rflfq=1&rlha=0&rllag=52327287,21186949,2293&tbm=lcl&rldimm=5147423853426772492&lqi=CgVlbWnFmyIDiAEBWg4KBWVtacWbIgVlbWnFmw&rldoc=1&tbs=lrf:!1m4!1u3!2m2!3m1!1e1!2m1!1e3!3sIAE,lf:1,lf_ui:4&rlst=f#rlfi=hd:;si:5147423853426772492,l,CgVlbWnFmyIDiAEBWg4KBWVtacWbIgVlbWnFmw;mv:[[52.37088360863484,21.27100297702189],[52.29367851805971,21.043551652559]]"
  ngOnInit(): void {
  }

}
