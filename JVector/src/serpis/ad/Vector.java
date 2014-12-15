package serpis.ad;

public class Vector {
	
	
	
	
	public static int min(int[]v){
		
		
		int min= v[0];
		
		for(int i=0;i<v.length;i++)
			if(v[i]<min)
				min=v[i];
		return min;		
	}
	
public static void main(String[]args){
		
		
		int[] v={1,5,7,4};
		int min=min(vector);
		System.out.println(min(v));
	}
}
