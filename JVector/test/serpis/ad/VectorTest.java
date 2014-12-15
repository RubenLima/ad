package serpis.ad;

import static org.junit.Assert.*;

import org.junit.Test;

public class VectorTest {

	@Test
	public void testMin() {
		fail("Not yet implemented");
		int[]vector=new int[]{33,14,14,15,87};
		int min=Vector.min(vector);
		
		assertEquals(0,Vector.min(new int[]{30,15,47,25}));

		assertEquals(0,Vector.min(new int[]{34,14,77,21}));

		assertEquals(0,Vector.min(new int[]{32,15,17,35}));
	}
	
	@Test(expected = ArrayIndexOutOfBoundsException.class)
	public void testMinEmpty(){
		Vector.min(new int[]{});
		
		
	}

}
