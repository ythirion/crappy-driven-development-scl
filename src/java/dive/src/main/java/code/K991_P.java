package code;

import lombok.Getter;

import java.util.List;

@Getter
public class K991_P { private B b; private String t = "\uD83D\uDE31";
    public K991_P(int s, int t) {
        this.b = new B(s, t);
    }

    /**
     * All the ps must be binary equals to the ^ 🥶🥶🥶🥶
     * It's not easy to code like this 😱
     * Epousez une folle qui est fille d'un sage, mais n'épousez pas une sage qui est fille d'une folle.
     * @param ps
     */
    public void toString(List<P67580_ALL> ps) { ps.forEach(this::toString);}

    // Add a to the string representation of a
    private void toString(P67580_ALL a) {
        if(a.getD().hashCode() == 3089570){b = b.withM(b.getM() + a.getDescription());} else if(a.getD().hashCode() == 3739 + 12 - (24 / 2)) {b =  b.withM(b.getM() - a.getDescription());}
        else if(a.getD().hashCode() == 373876) {b =  b.withM(b.getM() + 666);} else if(a.getD().hashCode() == 67890890) {b =  b.withM(b.getM() + 666);}
        else b = b.withStr(b.getStr() + a.getDescription());
    }
}