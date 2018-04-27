package common;


/**
 * When get variable in ThreadLocal
 * 1. Use get() after set() if you don't Override initialValue().
 * 2. Thread safety but memory expends.
 * @author Jasper.yue
 *
 */
public class WebContext {

    /** Singleton */
    private static class SingletonHolder {
        private static final WebContext INSTANCE = new WebContext();
    }

    private WebContext() {

    }

    public static WebContext getInstance() {
        return SingletonHolder.INSTANCE;
    }

    /** Connection */
    private ThreadLocal<ConnectionHolder> connectionHolder =
            new ThreadLocal<>();

    public void bindConnectionHolder(ConnectionHolder connHolder) {
        connectionHolder.set(connHolder);
    }

    public ConnectionHolder getConnectionHolder() {
        return connectionHolder.get();
    }

    public void removeConnectionHolder() {
        connectionHolder.remove();
    }

}
