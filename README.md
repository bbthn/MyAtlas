Onion architecture uygulandı. CQRS ve Mediator Pattern kullanıldı. Redis ve RabbitMQ implemente edilecek.

Genel işleyiş: Gelen http isteğindeki httpcontext işlerek (Presentation > ControllerManager > RequestServices > CurrentRequestService içerisinde) gerekli veriyi elde eder.
Sonrasında ilgili sayfa için gerekli datayı dbden çeker. Elde edilen datalar içerisinde hangi controller' ın kullanılıp hangi action' ın tetiklemnmesi gerektiği bilgisini 
bulup reflection kullanarak ilgili controller instance' ı oluşturup ilgili action invoke edilir(Presentation > ControllerManager > ResponseServices > CurrentResponseService). 
Gerekli ctor args. parameter arg. gibi bilgiler assembly işlemleri için yazmış olduğum AssemblyHelper içerisindeki metodlar aracılığıyla bulunup kulllanılır. 


