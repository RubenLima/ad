package serpis.ad;


import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityManager;
import javax.persistence.Persistence;

public class HibernateCategoria {
	private static EntityManagerFactory entityManagerFactory ; 
			

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		entityManagerFactory = 
				Persistence.createEntityManagerFactory("serpis.ad.jpa.mysql");
		
		showCategorias();
		persistNuevasCategorias();
		showArticulos();
		
		entityManagerFactory.close();
	}
	
	public static void persistNuevasCategorias(){
		

		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = new Categoria();
		categoria.setNombre(" hibernate"+ new SimpleDateFormat("yyyy-MM-dd HH:mm:ss").format(new Date()));
		
		
		entityManager.persist(categoria);
		
		entityManager.getTransaction().commit();
		entityManager.close();
	}
	public static void showCategorias(){
		
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Categoria> categorias = entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria categoria : categorias)
			System.out.printf("id=%d nombre=%s\n" , categoria.getId(),categoria.getNombre());
						
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
	public static void showArticulos(){
		
		
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Articulo> articulos = entityManager.createQuery("from Articulo", Articulo.class).getResultList();
		for (Articulo articulo : articulos)
			System.out.printf("id=%d nombre=%s\n" , articulo.getId(),articulo.getNombre(),articulo.getCategoria());
						
		entityManager.getTransaction().commit();
		entityManager.close();
		
	}
}