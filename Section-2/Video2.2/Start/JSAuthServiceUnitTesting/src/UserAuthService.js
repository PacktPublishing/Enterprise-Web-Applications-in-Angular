var AppUser = /** @class */ (function () {
  function AppUser(name, email, password) {
      this.name = "";
      this.email = "";
      this.password = "";
      this.role = "";
      this.sessionExpired = false;
      this.name = name;
      this.email = email;
      this.password = password;
      this.role = "";      
  }
  return AppUser;
}());
var AuthService = /** @class */ (function () {
  function AuthService(automaticTimeout) {
      this.timeoutInsec = 0;
      this.timeoutInsec = automaticTimeout;
  }
  AuthService.prototype.Login = function (name, email, password) {
      var _this = this;
      if(name == undefined || email == undefined || password == undefined){        
        throw('no/undefined parameters');
      }else{
        this.user = new AppUser(name, email, password);
        this.user.role = "Admin";
        setTimeout(function () {
            if (!_this.user.sessionExpired) {
                console.log('timed out');
                _this.user.sessionExpired = true;
            }
        }, this.timeoutInsec);
      }
  };
  AuthService.prototype.Logout = function () {
    this.Cleanup();  
    this.user = null;
  };
  AuthService.prototype.Cleanup = function () {
  };
  return AuthService;
}());


