package networking;
import java.util.Random;
public class KeywordGenerator {
    private char[] keyList;
    private Random r;
    public KeywordGenerator()
    {
        keyList =  "abcdefghijklmnopqrstuvwxyz0123456789".toCharArray();
        r = new Random();
    }

    public String genKeyword(int size)
    {
        String keyword = "";
        for (int i = 0; i < size; i++) {
            keyword += keyList[r.nextInt(keyList.length)];
        }
        return keyword;
    }
}
