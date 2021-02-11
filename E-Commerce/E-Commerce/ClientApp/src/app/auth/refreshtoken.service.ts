import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../../environments/environment';
import { Tokens } from '../models/tokens.model';

@Injectable({
  providedIn: 'root',
})
export class RefreshTokenService {
  private httpClient: HttpClient;
  constructor(handler: HttpBackend) {
    this.httpClient = new HttpClient(handler);
  }
  url: string = baseUrl + 'Identity/';
  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly REFRESH_TOKEN = 'REFRESH_TOKEN';
  refreshToken(): Observable<Tokens> {
    return this.httpClient.post<Tokens>(
      this.url + 'Refesh-Token',
      this.getTokens()
    );
  }

  getTokens() {
    let token: Tokens = {
      token: localStorage.getItem(this.JWT_TOKEN),
      refreshToken: localStorage.getItem(this.REFRESH_TOKEN),
    };
    return token;
  }
}
