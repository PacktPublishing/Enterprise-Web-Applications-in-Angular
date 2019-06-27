describe("User Auth Service Test Suite", function() {
  beforeAll(function(){});   

  describe("UserAuthService Constructor Specs", function(){    

    it('Accepts one parameter', function(){
        var parameter = 2000;
        var authSvc = new AuthService(parameter);
        expect(authSvc).not.toBeNull();
        expect(authSvc.timeoutInsec).toEqual(2000);
    });

    it('Timeout is undefined when no parameter is passed', function(){        
        var authSvc = new AuthService();
        expect(authSvc).not.toBeNull();
        expect(authSvc.timeoutInsec).toBeUndefined();
    });

  });

  describe("UserAuthService Login Specs", function(){
    var authService;
    var parameter = 5000;
    beforeEach(function(){
        authService = new AuthService(parameter); 
        
    });  

    it('Login function has been called with no parameter.', function(){        
        expect(function(){
            authService.Login();
        }).toThrow("no/undefined parameters");        
    });

    it('Login with all parameters', function(){
        authService.Login("Mark","Johnson","m.j@gmail.com");
        expect(authService.user).not.toBeUndefined();
        expect(authService.user.role).toEqual("Admin");
        
    });    
    

    afterEach(function(){        
        authService = null;
    });
  });
  
  describe("UserAuthService Login Auto Timed out Specs", function(){
    var originalTimeout;
    beforeEach(function() {
      originalTimeout = jasmine.DEFAULT_TIMEOUT_INTERVAL;
      jasmine.DEFAULT_TIMEOUT_INTERVAL = 10000;
    });

    it('Auto timed out', function(done){
        var _auth = new AuthService(5000); 
        _auth.Login("Mark","Johnson","m.j@gmail.com");
        expect(_auth.user.sessionExpired).toBe(false);
        setTimeout(function(){
            expect(_auth.user.sessionExpired).toBe(true);
            done();
        },5000);
    });
    afterEach(function() {
      jasmine.DEFAULT_TIMEOUT_INTERVAL = originalTimeout;
    });
  });

  describe("UserAuthService Logout Specs", function(){
    var authService;
    var parameter = 5000;
    beforeEach(function(){
        authService = new AuthService(parameter);               
    }); 

    it('Call Cleanup method', function(){
        spyOn(authService, 'Cleanup').and.returnValue(); 
        authService.Logout();
        expect(authService.Cleanup).toHaveBeenCalled();
    });

    it('User is null', function(){
        authService.Logout();
        expect(authService.user).toBeNull();
    });

    afterEach(function(){        
        authService = null;
    });
  });
  
  afterAll(function(){});  
});
